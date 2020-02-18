using GraphQL.Types;

namespace Server
{
    public class BlogMutation : ObjectGraphType
    {
        public BlogMutation(ArticleService articleService)
        {
            Field<ArticleType>(
                "create",
                arguments: new QueryArguments
                {
                    new QueryArgument<ArticleInputType> { Name = "article" }
                },
                resolve: context =>
                {
                    var article = context.GetArgument<Article>("article");
                    articleService.Articles.Add(article);
                    return article;
                });
        }
    }
}