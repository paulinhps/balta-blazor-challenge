using Flunt.Validations;

namespace IbgeBlazor.Core.Common.Commands.Contracts
{
    public class CommandValidator 
    {

        public static Contract<T> Validate<T>(Action<StandardCommandContract<T>> delegateValidations) where T: CommandBase {
            var contract = new StandardCommandContract<T>();

            delegateValidations?.Invoke(contract);

            return contract;
        }

        public class StandardCommandContract<T>: Contract<T> {
            
        }

    }
}