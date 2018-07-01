## Func Compose

```bash
dotnet add package wk.FuncCompose
```

## Usage

```csharp
using FuncCompose;

Func<Product, int> Price = (p) => p.Price;
Func<Product, bool> Stocked = (p) => p.Stocked;
Func<int, bool> IsCheap = (i) => i < 100;

bool IsCheap2(int i) => i < 100;

class Product {
    public bool Stocked { set; get; }
    public int Price { set; get; }
}

var products = new Product[] {
    new Product { Stocked = true, Price = 80 },
    new Product { Stocked = true, Price = 200 },
    new Product { Stocked = false, Price = 70},
};

var compose = products.Where(Stocked).Where(Price.Compose(IsCheap));
var and = products.Where(Stocked.And(Price.Compose(IsCheap)));
var or = products.Where(Stocked.Or(Price.Compose(IsCheap)));
```