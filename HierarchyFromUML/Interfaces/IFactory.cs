namespace HierarchyFromUML
{
    public interface IFactory
    {
        public IProductA ProduceProductA();
        
        public IProductB ProduceProductB();
    }
}
