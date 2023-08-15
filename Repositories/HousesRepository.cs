using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GregslistVande.Repositories
{
	public class HousesRepository
	{
		private readonly IDbConnection _db;
		public HousesRepository(IDbConnection db)
		{
			_db = db;
		}

		internal int CreateHouse(House houseData)
		{
			string sql = @"
						INSERT INTO houses(
							sqft,
							bedrooms,
							bathrooms,
							description,
							imgUrl,
							price
						)
						VALUES(
							@Sqft,
							@Bedrooms,
							@Bathrooms,
							@Description,
							@ImgUrl,
							@Price
						);
						SELECT LAST_INSERT_ID()
						;";

			int houseId = _db.ExecuteScalar<int>(sql, houseData);

			return houseId;
		}

		internal House EditHouse(House originalHouse)
		{
			string sql = @"UPDATE houses 
						SET
						sqft = @Sqft,
						bedrooms = @Bedrooms,
						bathrooms = @Bathrooms,
						imgUrl = @ImgUrl,
						description = @Description,
						price = @Price
						WHERE id = @Id
						LIMIT 1;
						SELECT * FROM houses WHERE id = @Id 
						;";

			House editedHouse = _db.QueryFirstOrDefault<House>(sql, originalHouse);

			return editedHouse;
		}

		internal House GetHouseById(int houseId)
		{
			string sql = "SELECT * FROM houses WHERE id = @houseId;";

			House house = _db.QueryFirstOrDefault<House>(sql, new { houseId });

			return house;
		}

		internal List<House> GetHouses()
		{
			string sql = "SELECT * FROM houses;";

			List<House> houses = _db.Query<House>(sql).ToList();

			return houses;
		}

		internal void RemoveHouse(int houseId)
		{
			string sql = "DELETE FROM houses WHERE id = @houseId LIMIT 1";

			_db.Execute(sql, new { houseId });
		}
	}
}