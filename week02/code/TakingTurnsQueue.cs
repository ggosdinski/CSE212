public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.Length == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // **CORRECCIÓN:** Primero devolver la persona ANTES de modificar `Turns`
        Person result = new Person(person.Name, person.Turns);

        // Si el jugador tiene turnos infinitos (turns <= 0), lo volvemos a encolar siempre
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // Si aún tiene turnos restantes, reducimos su turno y lo volvemos a encolar
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // Si era su último turno, simplemente lo sacamos de la cola (NO lo reinsertamos)

        return result;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
