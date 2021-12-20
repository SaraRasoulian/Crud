namespace sage.challenge.model
{
    public interface IBuilder<TEntity, TViewModel>
    {
        TEntity BuildEntity(TViewModel viewModel);
        TViewModel BuildViewModel(TEntity entity);
        TViewModel RebuildViewModel(TViewModel viewModel);
    }
}
