namespace IbgeBlazor.Core.Common.Commands.Entities;

public abstract class Entity : GenericEntity<int>
{
    public Entity(int id) : base(id)
    {
        if (id <= 0)
            AddNotification("Entity.Id", "Id is Required");
    }

}
