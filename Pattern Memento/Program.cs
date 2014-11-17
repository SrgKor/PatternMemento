// Паттерн Memento (Память)
// Позволяет фиксировать состояние некоторого объекта в определенном моменте, 
// с тем чтобы потом можно было восстановить это состояние.
// Позволяет не напрямую изменять состояние объекта а через некоторый интерфейс, сохраняя инкапсуляцию объекта.
// Применяется для ведения history.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern_Memento
{
    class Program
    {
        static void Main()
        {
            Originator o = new Originator();
            o.State = "On";

            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            o.State = "Off";

            o.SetMemento(c.Memento);
            Console.Read();
        }
    }

    // Тот объект состояние которого нас интересует
    class Originator 
    {
        private string _state;
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("My State = " + _state);
            }
        }

        // создает memento , содержащий снимок текущего внутреннего состояния
        public Memento CreateMemento()    // метод возвращает объект типа memento в котором сохранено состояние state
        {
            return (new Memento(_state));
        }

        // использует хранитель для восстановления внутреннего состояния
        public void SetMemento(Memento memento)     // метод восстанавливает состояние (переданное в качестве параметра)
        {
            Console.WriteLine("Restoring my state...");
            State = memento.State;
        }
    }

    // Хранитель. Сохраняет внутреннее состояние объекта Originator.
    class Memento                                   
    {
        private string _state;   // поле для сохранения состояния                  

        public Memento(string state) // конструктор принимает это состояние
        {
              this._state = state;
        }

        public string State // может вернуть состояние
        {
              get { return _state;}
        }
     }

    // Посыльный, механизм отката.
    // - отвечает за сохранение хранителя;
    // - не производит никаких операций над хранителем и не исследует его внутреннее содержимое.

    class Caretaker                
     {
          private Memento _memento;
          public Memento Memento
          {
                set { _memento = value;}
                get { return _memento; }
          }
     }
}