namespace Launcher
{
    public interface IRule<in TInput, out TOutput>
    {
        TOutput Apply(TInput input);
        bool IsApplicable(TInput input);
    }
}