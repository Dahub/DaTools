namespace DaTools.WebApi.Core.Interfaces
{
    public interface ISearchCriteriasDto : IDto
    {
        uint Skip { get; set; }
        uint Limit { get; set; }
    }
}
