using Guyusoft.IMS.Utility.DataContract.SQLGenerator;

namespace Guyusoft.IMS.DatabaseService.DataContract
{
    public interface ISqlGeneratorFactory
    {
        ISqlGenerator GetGenerator(SQLGenerationAction action);
    }
}
