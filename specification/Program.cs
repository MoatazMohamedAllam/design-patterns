using MediatR;
using Microsoft.EntityFrameworkCore;
using specification.Data;
using specification.Features.Posts.Create;
using specification.Features.Posts.Read;
using specification.Features.Posts.ReadAll;
using specification.Repository;
using FluentValidation;
using specification.PipelineBehaviors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkInMemoryDatabase();
builder.Services.AddScoped<IPostsRepository, PostsRepository>();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddDbContext<AppDataContext>(opts => { opts.UseInMemoryDatabase("PostsDB"); });


//order of pipelineBehaviors is cruical
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingPipelineBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionPipelineBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();


using var scope = app.Services.CreateScope();
var ctx = scope.ServiceProvider.GetService<AppDataContext>();
SeedData(ctx);


app.MapGet("/posts", async (IMediator _mediator) =>
    {
        var result = _mediator.Send(new GetAllPostsQuery());
        // var result = 
        //     postsRepository.GetPostsForSpecificUser(new PostsForSpecificUserSpecification("Moataz"));
        // var result = await ctx.Posts
        //     .Where(x => x.CreatedBy == "Moataz")
        //     .Include(ctx => ctx.Comments)
        //     .ToListAsync();
        return Results.Ok(result);
    })
    .WithName("GetAllPosts")
    .WithOpenApi();

app.MapGet("/posts/{id}", async (int id, IMediator _mediator) =>
    {
        throw new Exception("throw exception");
        var x = await _mediator.Send(new GetPostByIdQuery(id));
        return Results.Ok(x);
    })
    .WithName("GetPostById")
    .WithOpenApi();

app.MapPost("/posts", async (IMediator _mediator, CreatePostCommand command) =>
    {
        var x = await _mediator.Send(command);
        return Results.Ok(x);
    })
    .WithName("CreatePost")
    .WithOpenApi();

app.Run();


void SeedData(AppDataContext? appDataContext)
{
    if (!appDataContext.Posts.Any())
    {
        //seed data here
        appDataContext.Posts.Add(new Post
        {
            Title = "test1", CreatedBy = "Moataz", 
            Comments = new List<Comment>
            {
                new() { Title = "very good post", CreatedBy = "Ali", CreatedDate = DateTime.Now },
                new() { Title = "tahnks for sharing", CreatedBy = "Sara", CreatedDate = DateTime.Now }
            }
        });

        appDataContext.Posts.Add(new Post
        {
            Title = "test2", CreatedBy = "Alaa",
            Comments = new List<Comment>
            {
                new() { Title = "brilliant!", CreatedBy = "Karim", CreatedDate = DateTime.Now },
                new() { Title = "amazing post!", CreatedBy = "Ahmed", CreatedDate = DateTime.Now }
            }
        });

        appDataContext.SaveChanges();
    }
}