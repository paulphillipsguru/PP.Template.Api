namespace PP.Template.Messages.Example.Commands.Example
{
    public class AddNewExampleCommand : IRequest<long>
    {
        public required string Name { get; set; }    
    }
}
