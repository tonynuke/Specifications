# Specifications
DDD specifications c# implementation.

## How to use
### Create specification
Inherit from the `SpecificationBase<T>` class or use the `Specification<Entity>.Create`.
```c#
Entity entity;
DateTime date = DateTime.Now;
var specification = Specification<Entity>.Create(entity => entity.CreationDate == date);
bool isSatisfied = todaySpecification.IsSatisfiedBy(entity);
```
Other usage examples you can see in [tests](https://github.com/tonynuke/Specifications/tree/master/Specifications.UnitTests).

### LINQ
```c#
Enumerable.Range(0, 10).AsQueryable().Where(specification);
```

### Entity Framework Core
```c#
DbContext _dbContext;
_dbContext.Entities.AsQueryable().Where(specification);
```

### MongoDB C#/.NET Driver
```c#
IMongoCollection<Entity> collection;
collection.FindAsync(specification.ToExpression());
collection.Find(specification.ToExpression());
collection.AsQueryable().Where(specification);
```
