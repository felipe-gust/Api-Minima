namespace PizzaStore.Db;

public record Pizza
{
    public int Id { get; set; }
    public string ? Name { get; set; }
}

public class PizzaDb 
{
    private static List<Pizza> _pizzas = new List<Pizza>()
    {
        new Pizza{ Id=1, Name="Calabacon, pizza de calabresa fatiada com bacon em pedaços" },
        new Pizza{ Id=2, Name="Três queijos, pizza de queijo parmesão, gorgonzola e requeijão" },
        new Pizza{ Id=3, Name="Romeu e Julieta, pizza com goiabada derretida e queijo minas frescal" }
    };

    public static List<Pizza> GetPizzas()
    {
        return _pizzas;
    }

    public static Pizza ? GetPizza(int id)
    {
        return _pizzas.SingleOrDefault(pizza => pizza.Id == id);
    }

    public static Pizza CreatePizza(Pizza pizza)
    {
        _pizzas.Add(pizza);
        return pizza;
    }

    public static Pizza UpdatePizza(Pizza update)
    {
        _pizzas = _pizzas.Select(pizza =>
        {
            if(pizza.Id == update.Id)
            {
                pizza.Name = update.Name;
            }
            return pizza;
        }).ToList();
        return update;
    }

    public static void RemovePizza(int id)
    {
        _pizzas = _pizzas.FindAll(pizza => pizza.Id != id).ToList();
    }
}