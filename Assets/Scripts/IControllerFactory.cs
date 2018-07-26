public interface IControllerFactory
{
    IInputController GetFirstPlayer();
    IInputController GetSecondPlayer();
}