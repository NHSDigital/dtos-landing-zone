using Model;

namespace Data.Database;
public interface ICreateDemographicData
{
    public bool InsertDemographicData(Participant participant);
}