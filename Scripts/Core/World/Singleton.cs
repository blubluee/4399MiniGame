public abstract class ASingleton: DisposeObject {
    internal abstract void Register();
}

public abstract class Singleton<T>: ASingleton where T: Singleton<T> {

    private bool _isDisposed;

    public static T Instance { get; private set; }

    internal override void Register() {
        Instance = (T)this;
    }

    public bool IsDisposed() {
        return this._isDisposed;
    }

    protected virtual void Destroy() {

    }

    public override void Dispose() {
        if (this._isDisposed) {
            return;
        }

        this._isDisposed = true;

        this.Destroy();
        
        Instance = null;
    }

}