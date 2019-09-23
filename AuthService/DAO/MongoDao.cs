using MongoWrapper;

namespace AuthService.DAO
{
    internal static class MongoDao
    {
        public static readonly MongoWrap Mongo;

        static MongoDao()
        {
            Mongo = MongoWrap.FromConfig("MongoConnection");
        }
    }
}
