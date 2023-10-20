namespace Shop.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"Сущность {name} не содержит Id:{key} ")
        {

        }
    }
}
