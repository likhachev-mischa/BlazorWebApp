using Microsoft.EntityFrameworkCore;

namespace Lab
{
	public class PhilosophersDbStorage
	{
		private readonly PhilosopherContext m_context;

		public PhilosophersDbStorage(PhilosopherContext context)
		{
			m_context = context;
		}

		public async Task AddPhilosopherAsync(Philosopher philosopher)
		{
			m_context.Philosophers.Add(philosopher);
			await m_context.SaveChangesAsync();
		}

		public async Task<Philosopher?> GetPhilosopherAsync(int id)
		{
			Philosopher? philosopher = await m_context.Philosophers.FirstOrDefaultAsync(x => x.PhilosopherId == id);
			return philosopher;
		}

		public Philosopher? GetPhilosopher(int id)
		{
			return m_context.Philosophers.FirstOrDefault(x => x.PhilosopherId == id);
		}

		public async Task<List<Philosopher>> GetPhilosophersAsync(string name)
		{
			var philosophers = await m_context.Philosophers.Where(x => x.PhilosopherName == name).ToListAsync();
			return philosophers;
		}

		public async Task<List<Philosopher>> GetPhilosophersAsync()
		{
			return await m_context.Philosophers.ToListAsync();
		}

		public async Task RemovePhilosopherAsync(Philosopher philosopher)
		{
			List<PhilosopherStudentConnection> entities = await m_context.PhilosopherStudentConnections.ToListAsync();
			entities = entities.FindAll(x =>
				x.Student?.PhilosopherId == philosopher.PhilosopherId ||
				x.Teacher?.PhilosopherId == philosopher.PhilosopherId);

			if (entities.Count != 0)
			{
				m_context.PhilosopherStudentConnections.RemoveRange(entities);
			}

			m_context.Philosophers.Remove(philosopher);
			await m_context.SaveChangesAsync();
		}

		public async Task RemovePhilosopherAsync(string philosopherName)
		{
			List<PhilosopherStudentConnection> entities = await m_context.PhilosopherStudentConnections.ToListAsync();
			entities = entities.FindAll(x =>
				x.Student?.PhilosopherName == philosopherName ||
				x.Teacher?.PhilosopherName == philosopherName);

			if (entities.Count != 0)
			{
				m_context.PhilosopherStudentConnections.RemoveRange(entities);
			}

			m_context.Philosophers.RemoveRange(await GetPhilosophersAsync(philosopherName));
			await m_context.SaveChangesAsync();
		}

		public async Task AddPhilosophyAsync(Philosophy philosophy)
		{
			m_context.Philosophies.Add(philosophy);
			await m_context.SaveChangesAsync();
		}

		public Philosophy? GetPhilosophy(int id)
		{
			return m_context.Philosophies.FirstOrDefault(x => x.PhilosophyId == id);
		}

		public async Task<Philosophy?> GetPhilosophyAsync(int id)
		{
			Philosophy? philosophy = await m_context.Philosophies.FirstOrDefaultAsync(x => x.PhilosophyId == id);
			return philosophy;
		}

		public async Task<List<Philosophy>> GetPhilosophiesAsync(string name)
		{
			var philosophies = await m_context.Philosophies.Where(x => x.PhilosophyName == name).ToListAsync();
			return philosophies;
		}

		public async Task<List<Philosophy>> GetPhilosophiesAsync()
		{
			return await m_context.Philosophies.ToListAsync();
		}

		public async Task RemovePhilosophyAsync(Philosophy philosophy)
		{
			m_context.Philosophies.Remove(philosophy);
			await m_context.SaveChangesAsync();
		}

		public async Task RemovePhilosophyAsync(string philosophyName)
		{
			m_context.Philosophies.RemoveRange(await GetPhilosophiesAsync(philosophyName));
			await m_context.SaveChangesAsync();
		}

		public async Task AddCountryAsync(Country country)
		{
			m_context.Countries.Add(country);
			await m_context.SaveChangesAsync();
		}

		public Country? GetCountry(int id)
		{
			return m_context.Countries.FirstOrDefault(x => x.CountryId == id);
		}

		public async Task<Country?> GetCountryAsync(int id)
		{
			Country? country = await m_context.Countries.FirstOrDefaultAsync(x => x.CountryId == id);
			return country;
		}

		public async Task<List<Country>> GetCountriesAsync()
		{
			var countries = await m_context.Countries.ToListAsync();
			return countries;
		}

		public async Task<List<Country>> GetCountriesAsync(string name)
		{
			var countries = await m_context.Countries.Where(x => x.CountryName == name).ToListAsync();
			return countries;
		}

		public async Task RemoveCountryAsync(Country country)
		{
			m_context.Countries.Remove(country);
			await m_context.SaveChangesAsync();
		}

		public async Task RemoveCountryAsync(string countryName)
		{
			m_context.Countries.RemoveRange(await GetCountriesAsync(countryName));
			await m_context.SaveChangesAsync();
		}

		public async Task AddWorkAsync(Work work)
		{
			m_context.Works.Add(work);
			await m_context.SaveChangesAsync();
		}

		public Work? GetWork(int id)
		{
			return m_context.Works.FirstOrDefault(x => x.WorkId == id);
		}

		public async Task<Work?> GetWorkAsync(int id)
		{
			Work? work = await m_context.Works.FirstOrDefaultAsync(x => x.WorkId == id);
			return work;
		}

		public async Task<List<Work>> GetWorksAsync()
		{
			var works = await m_context.Works.ToListAsync();
			return works;
		}


		public async Task<List<Work>> GetWorksAsync(string name)
		{
			var works = await m_context.Works.Where(x => x.WorkName == name).ToListAsync();
			return works;
		}

		public async Task RemoveWorkAsync(Work work)
		{
			m_context.Works.Remove(work);
			await m_context.SaveChangesAsync();
		}

		public async Task RemoveWorkAsync(string name)
		{
			m_context.Works.RemoveRange(await GetWorksAsync(name));
			await m_context.SaveChangesAsync();
		}

		public async Task AddPccAsync(PhilosopherCountryConnection pcc)
		{
			m_context.PhilosopherCountryConnections.Add(pcc);
			await m_context.SaveChangesAsync();
		}

		public async Task<List<PhilosopherCountryConnection>> GetPccsAsync()

		{
			return await m_context.PhilosopherCountryConnections.ToListAsync();
		}


		public async Task<PhilosopherCountryConnection?> GetPccAsync(int id)
		{
			PhilosopherCountryConnection? pcc = await
				m_context.PhilosopherCountryConnections.FirstOrDefaultAsync(x =>
					x.PhilosopherCountryConnectionId == id);
			return pcc;
		}

		public PhilosopherCountryConnection? GetPcc(int id)
		{
			return m_context.PhilosopherCountryConnections.FirstOrDefault(x =>
				x.PhilosopherCountryConnectionId == id);
		}

		public async Task RemovePccAsync(PhilosopherCountryConnection pcc)
		{
			m_context.PhilosopherCountryConnections.Remove(pcc);
			await m_context.SaveChangesAsync();
		}

		public async Task AddPpcAsync(PhilosopherPhilosophyConnection ppc)
		{
			m_context.PhilosopherPhilosophiesConnections.Add(ppc);
			await m_context.SaveChangesAsync();
		}

		public async Task<List<PhilosopherPhilosophyConnection>> GetPpcsAsync()
		{
			return await m_context.PhilosopherPhilosophiesConnections.ToListAsync();
		}

		public async Task<PhilosopherPhilosophyConnection?> GetPpcAsync(int id)
		{
			PhilosopherPhilosophyConnection? ppc = await
				m_context.PhilosopherPhilosophiesConnections.FirstOrDefaultAsync(
					x => x.PhilosopherPhilosophyConnectionId == id);
			return ppc;
		}

		public async Task RemovePpcAsync(PhilosopherPhilosophyConnection ppc)
		{
			m_context.PhilosopherPhilosophiesConnections.Remove(ppc);
			await m_context.SaveChangesAsync();
		}

		public async Task AddPscAsync(PhilosopherStudentConnection psc)
		{
			m_context.PhilosopherStudentConnections.Add(psc);
			await m_context.SaveChangesAsync();
		}

		public PhilosopherPhilosophyConnection? GetPpc(int id)
		{
			return m_context.PhilosopherPhilosophiesConnections.FirstOrDefault(x =>
				x.PhilosopherPhilosophyConnectionId == id);
		}

		public async Task<PhilosopherStudentConnection?> GetPscAsync(int id)
		{
			PhilosopherStudentConnection? psc = await
				m_context.PhilosopherStudentConnections.FirstOrDefaultAsync(x =>
					x.PhilosopherStudentConnectionId == id);
			return psc;
		}

		public PhilosopherStudentConnection? GetPsc(int id)
		{
			return m_context.PhilosopherStudentConnections.FirstOrDefault(x => x.PhilosopherStudentConnectionId == id);
		}

		public async Task<List<PhilosopherStudentConnection>> GetPscsAsync()
		{
			return await m_context.PhilosopherStudentConnections.ToListAsync();
		}


		public async Task RemovePscAsync(PhilosopherStudentConnection psc)
		{
			m_context.PhilosopherStudentConnections.Remove(psc);
			await m_context.SaveChangesAsync();
		}
	}
}