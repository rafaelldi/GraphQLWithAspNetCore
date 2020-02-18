using GraphQL.Types;

namespace Server
{
    public class ArticleType : ObjectGraphType<Article>
    {
        public ArticleType()
        {
            Field(x => x.Title);
            Field(x => x.Author);
            Field(x => x.Content);
        }
    }
}