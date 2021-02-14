# Specifications
DDD specifications c# implementation.

## How to use
### Create specification
Inherit from `SpecificationBase<T>` class or user `Specification<Entity>.Create`.
```c#
Entity entity;
DateTime date = DateTime.Now;
var specification = Specification<Entity>.Create(entity => entity.CreationDate == date);
bool isSatisfied = todaySpecification.IsSatisfiedBy(entity);
```
Other usage examples you can see in [tests](https://github.com/tonynuke/Specifications/tree/master/SpecificationsTests).

### LINQ
```c#
Enumerable.Range(0, 10).AsQueryable().Where(specification.ToExpression());
```

### Entity Framework Core
```c#
DbContext _dbContext;
_dbContext.Entities.AsQueryable().Where(specification.ToExpression());
```

### MongoDB C#/.NET Driver
```c#
IMongoCollection<Entity> collection;
collection.FindAsync(specification.ToExpression())
```
