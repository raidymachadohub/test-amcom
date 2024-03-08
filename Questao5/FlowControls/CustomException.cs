namespace Questao5.FlowControls
{
    [Serializable]
    public class CustomException : Exception
    {
        public CustomException ()
        {}

        public CustomException (string message) 
            : base(message)
        {}
        public CustomException (Error error)
            : base (error.Negocio.ToString() + ": " + error.Descricao)
        {}    
    }
    
}