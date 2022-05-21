using System;

namespace AsteroidsGame_HomeWork_
{
    class GameObjectException : ArgumentOutOfRangeException
    {
        public override string Message => "Отрицательный размер объекта";
    }
}
