using FullStackDevExercise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullStackDevExercise.Data
{
  public class OwnerRepository : IOwnerRepository
  {
    private readonly DataContext context;
    public OwnerRepository(DataContext Context)
    {
      context = Context;
    }

    public Owner GetById(int id)
    {
      return context.Owners.Include(c => c.Pets)
        .Where(c=>c.id==id).FirstOrDefault();
    }

    public IQueryable<Owner> GetAll()
    {
      return context.Owners.Include(c => c.Pets);
    }

    public int Save(Owner owner)
    {
      //to do check whether actual id is needed in UI after this operatation.
      //Ideally all these methods should be async.
      context.Owners.Add(owner);
      return context.SaveChanges();
    }

    public int SavePet(Pet entity)
    {
      context.Pets.Attach(entity);
      return context.SaveChanges();
    }


    public int Delete(int id)
    {
      var owner = new Owner()
      {
        id = id
      };
      context.Remove(owner);
      return context.SaveChanges();
    }
  }
}
