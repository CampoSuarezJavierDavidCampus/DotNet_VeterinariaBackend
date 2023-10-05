namespace Core.Interfaces;
public interface IPager<T>{
    IParam Conf {get; }
    int Total { get; }
    List<T> Registers {get; }
    int TotalPages { get; }
    bool HasPreviousPage{ get; }
    bool HasNextPage {get; }
}
