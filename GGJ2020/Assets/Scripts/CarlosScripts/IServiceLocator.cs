namespace GGJ2020 {
	public interface IServiceLocator {
		T Resolve<T>() where T : class;
		void Register<T>(T service) where T : class;
	}
}