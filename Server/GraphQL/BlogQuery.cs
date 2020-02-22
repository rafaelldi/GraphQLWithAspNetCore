using System.Linq;
using GraphQL;
using GraphQL.Types;

namespace Server.GraphQL
{
    public class BlogQuery : ObjectGraphType
    {
        public BlogQuery(ArticleService articleService)
        {
            Field<ListGraphType<ArticleType>>("list", resolve: context => articleService.Articles);
            Field<ListGraphType<ArticleType>>(
                "filtered-list", 
                arguments: new QueryArguments
                {
                    new  QueryArgument<StringGraphType> { Name = "title"}    
                },
                resolve: context =>
                {
                    var titleFilter = context.GetArgument<string>("title");
                    return articleService.Articles.Where(a => a.Title == titleFilter);
                });
        }
    }
}