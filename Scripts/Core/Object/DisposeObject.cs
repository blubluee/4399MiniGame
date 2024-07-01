public abstract class DisposeObject: Object {
    public virtual void Dispose() {}

}

public interface IPool {
    bool IsFromPool {
        get;
        set;
    }
}
