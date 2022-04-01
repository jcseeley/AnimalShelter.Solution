using AnimalShelter.Filters;
using System;

public interface IUriService
{
  public Uri GetPageUri(PaginationFilter filter, string route);
}