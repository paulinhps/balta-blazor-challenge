using Flunt.Validations;

namespace IbgeBlazor.Core.Common.Commands.Contracts
{
    internal class CommandValidator 
    {

        public static Contract<T> Validate<T>(Action<StandardCommandContract<T>> delegateValidations) where T: CommandBase {
            var contract = new StandardCommandContract<T>();

            delegateValidations?.Invoke(contract);

            return contract;
        }

        internal class StandardCommandContract<T>: Contract<T> {
            
        }

    }
}