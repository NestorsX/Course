namespace HierarchyFromUML
{
    public class Factory2 : IFactory
    {
        public IProductA ProduceProductA()
        {
            return new ProductA2();
        }

        public IProductB ProduceProductB()
        {
            return new ProductB2();
        }
    }
}
