namespace MuseumSort.Common.BaseModels
{
    public class BaseTableViewModel<T>
    {
        public int RecordsTotal { get; set; }
        public string? SortOrder {  get; set; }
        public List<T> Data { get; set; }
    }
}
