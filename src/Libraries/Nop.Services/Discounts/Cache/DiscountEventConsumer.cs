using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Configuration;
using Nop.Core.Domain.Discounts;
using Nop.Core.Events;
using Nop.Services.Events;

namespace Nop.Services.Discounts.Cache
{
    /// <summary>
    /// Cache event consumer (used for caching of discounts)
    /// </summary>
    public partial class DiscountEventConsumer :
        //discounts
        IConsumer<EntityInsertedEvent<Discount>>,
        IConsumer<EntityUpdatedEvent<Discount>>,
        IConsumer<EntityDeletedEvent<Discount>>,
        //discount requirements
        IConsumer<EntityInsertedEvent<DiscountRequirement>>,
        IConsumer<EntityUpdatedEvent<DiscountRequirement>>,
        IConsumer<EntityDeletedEvent<DiscountRequirement>>,
        //settings
        IConsumer<EntityUpdatedEvent<Setting>>,
        //categories
        IConsumer<EntityInsertedEvent<Category>>,
        IConsumer<EntityUpdatedEvent<Category>>,
        IConsumer<EntityDeletedEvent<Category>>,
        //manufacturers
        IConsumer<EntityInsertedEvent<Manufacturer>>,
        IConsumer<EntityUpdatedEvent<Manufacturer>>,
        IConsumer<EntityDeletedEvent<Manufacturer>>
    {
        private readonly IStaticCacheManager _cacheManager;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cacheManager">Cache manager</param>
        public DiscountEventConsumer(IStaticCacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        //discounts
        public void HandleEvent(EntityInsertedEvent<Discount> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountAllPatternCacheKey);
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountRequirementPatternCacheKey);
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountCategoryIdsPatternCacheKey);
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountManufacturerIdsPatternCacheKey);
        }
        public void HandleEvent(EntityUpdatedEvent<Discount> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountAllPatternCacheKey);
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountRequirementPatternCacheKey);
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountCategoryIdsPatternCacheKey);
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountManufacturerIdsPatternCacheKey);
        }
        public void HandleEvent(EntityDeletedEvent<Discount> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountAllPatternCacheKey);
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountRequirementPatternCacheKey);
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountCategoryIdsPatternCacheKey);
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountManufacturerIdsPatternCacheKey);
        }

        //discount requirements
        public void HandleEvent(EntityInsertedEvent<DiscountRequirement> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountRequirementPatternCacheKey);
        }
        public void HandleEvent(EntityUpdatedEvent<DiscountRequirement> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountRequirementPatternCacheKey);
        }
        public void HandleEvent(EntityDeletedEvent<DiscountRequirement> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountRequirementPatternCacheKey);
        }


        //settings
        public void HandleEvent(EntityUpdatedEvent<Setting> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountCategoryIdsPatternCacheKey);
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountManufacturerIdsPatternCacheKey);
        }

        //categories
        public void HandleEvent(EntityInsertedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountCategoryIdsPatternCacheKey);
        }
        public void HandleEvent(EntityUpdatedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountCategoryIdsPatternCacheKey);
        }
        public void HandleEvent(EntityDeletedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountCategoryIdsPatternCacheKey);
        }


        //manufacturers
        public void HandleEvent(EntityInsertedEvent<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountManufacturerIdsPatternCacheKey);
        }
        public void HandleEvent(EntityUpdatedEvent<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountManufacturerIdsPatternCacheKey);
        }
        public void HandleEvent(EntityDeletedEvent<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopDiscountsDefaults.DiscountManufacturerIdsPatternCacheKey);
        }
    }
}
