﻿using InvoiceApi.Database.Interfaces;
using InvoiceApi.Database.Models;

namespace InvoiceApi.Database.Reporsitories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
    }
}
