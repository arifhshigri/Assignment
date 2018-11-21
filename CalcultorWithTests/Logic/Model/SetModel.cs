namespace CalculatorLogic.Model
{
    public class SetModel
    {
        public SetModel()
        {
            Set = new BasicArthematicModel();
        }

        public BasicArthematicModel Set { get; set; }
    }
}
