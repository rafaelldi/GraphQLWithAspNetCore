using GraphQL.Types;

namespace Server
{
    public class BlogQuery : ObjectGraphType
    {
        public BlogQuery(ArticleService articleService)
        {
            Field<ListGraphType<ArticleType>>(
                "list", 
                resolve: context => articleService.Articles);
        }
    }
}