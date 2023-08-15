using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GregslistVande.Services
{
	public class HousesService
	{
		private readonly HousesRepository _housesRepository;
		public HousesService(HousesRepository housesRepository)
		{
			_housesRepository = housesRepository;
		}

		internal House CreateHouse(House houseData)
		{
			int houseId = _housesRepository.CreateHouse(houseData);

			House house = GetHouseById(houseId);

			return house;
		}

		internal House EditHouse(int houseId, House houseData)
		{
			House originalHouse = GetHouseById(houseId);

			originalHouse.Sqft = houseData.Sqft ?? originalHouse.Sqft;
			originalHouse.Bedrooms = houseData.Bedrooms ?? originalHouse.Bedrooms;
			originalHouse.Bathrooms = houseData.Bathrooms ?? originalHouse.Bathrooms;
			originalHouse.ImgUrl = houseData.ImgUrl ?? originalHouse.ImgUrl;
			originalHouse.Description = houseData.Description ?? originalHouse.Description;
			originalHouse.Price = houseData.Price ?? originalHouse.Price;

			House house = _housesRepository.EditHouse(originalHouse);

			return house;
		}

		internal House GetHouseById(int houseId)
		{
			House house = _housesRepository.GetHouseById(houseId);

			if (house == null)
			{
				throw new Exception($"{houseId} is not a valid ID");
			}

			return house;
		}

		internal List<House> GetHouses()
		{
			List<House> houses = _housesRepository.GetHouses();
			return houses;
		}

		internal House RemoveHouse(int houseId)
		{
			House house = GetHouseById(houseId);

			_housesRepository.RemoveHouse(houseId);

			return house;
		}
	}
}