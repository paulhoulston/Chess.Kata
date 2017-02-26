using System;

namespace Chess.Kata.Pieces.Validators
{
    public class ValidatorCollection
    {
        readonly IValidateMoves[] _validators;
        readonly Action _onMoveIsValid;

        public ValidatorCollection(Action onMoveIsValid, params IValidateMoves[] validators)
        {
            _onMoveIsValid = onMoveIsValid;
            _validators = validators;
        }

        public void IsValid(Position newPosition)
        {
            RecurseThroughValidators(newPosition, _validators[0], 0);
        }

        void RecurseThroughValidators(Position newPosition, IValidateMoves validator, int i)
        {
            Action validDelegate = i == _validators.Length - 1 ?
                                    _onMoveIsValid :
                                    () => RecurseThroughValidators(newPosition, _validators[i + 1], i + 1);

            validator.IsValid(newPosition, validDelegate);
        }
    }
}