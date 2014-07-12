using System;

namespace Metsys.Bson.Configuration
{
    public interface ITypeConfiguration
    {
        ITypeConfiguration Ignore(Type type, string name);
    }

    public class TypeConfiguration : ITypeConfiguration
    {
        private readonly BsonConfiguration _configuration;

        internal TypeConfiguration(BsonConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ITypeConfiguration Ignore(Type type, string name)
        {
            _configuration.AddIgnore(type, name);
            return this;
        }
    }
}
