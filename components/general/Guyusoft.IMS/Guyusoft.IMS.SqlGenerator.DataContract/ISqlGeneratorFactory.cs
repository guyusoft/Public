namespace Guyusoft.IMS.SqlGenerator.DataContract
{
    public interface ISqlGeneratorFactory
    {
        ISqlGenerator Create(Generator generatorType);
    }
}
