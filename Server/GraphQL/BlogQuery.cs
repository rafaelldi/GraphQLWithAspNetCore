using GraphQL.Types;

namespace Server.GraphQL
{
    public class BlogQuery : ObjectGraphType
    {
        public BlogQuery(ArticleService articleService)
        {
            Field<ListGraphType<ArticleType>>("list", resolve: context => articleService.Articles);
        }
    }
}