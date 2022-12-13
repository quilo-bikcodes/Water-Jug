using System;
using System.Collections.Generic;

class solution {

	static void BFS(int a, int b, int target)
	{

		Dictionary<Tuple<int, int>, int> m
			= new Dictionary<Tuple<int, int>, int>();
		bool isSolvable = false;
		List<Tuple<int, int> > path
			= new List<Tuple<int, int> >();
		// Queue to maintain states
		List<Tuple<int, int> > q
			= new List<Tuple<int, int> >();

		// Initializing with initial state
		q.Add(new Tuple<int, int>(0, 0));

		while (q.Count > 0) {

			// Current state
			Tuple<int, int> u = q[0];

			// Pop off used state
			q.RemoveAt(0);

			// If this state is already visited
			if (m.ContainsKey(u) && m[u] == 1)
				continue;

			// Doesn't met jug constraints
			if ((u.Item1 > a || u.Item2 > b || u.Item1 < 0
				|| u.Item2 < 0))
				continue;

			// Filling the vector for constructing
			// the solution path
			path.Add(u);

			// Marking current state as visited
			m[u] = 1;

			// If we reach solution state, put ans=1
			if (u.Item1 == target || u.Item2 == target) {
				isSolvable = true;

				if (u.Item1 == target) {
					if (u.Item2 != 0)

						// Fill final state
						path.Add(new Tuple<int, int>(
							u.Item1, 0));
				}
				else {
					if (u.Item1 != 0)

						// Fill final state
						path.Add(new Tuple<int, int>(
							0, u.Item2));
				}

				// Print the solution path
				int sz = path.Count;
				for (int i = 0; i < sz; i++)
					Console.WriteLine("(" + path[i].Item1
									+ ", " + path[i].Item2
									+ ")");
				break;
			}

			q.Add(new Tuple<int, int>(u.Item1, b));

			// Fill Jug1
			q.Add(new Tuple<int, int>(a, u.Item2));

			for (int ap = 0; ap <= Math.Max(a, b); ap++) {

				// Pour amount ap from Jug2 to Jug1
				int c = u.Item1 + ap;
				int d = u.Item2 - ap;

				// Check if this state is possible or not
				if (c == a || (d == 0 && d >= 0))
					q.Add(new Tuple<int, int>(c, d));

				// Pour amount ap from Jug 1 to Jug2
				c = u.Item1 - ap;
				d = u.Item2 + ap;

				// Check if this state is possible or not
				if ((c == 0 && c >= 0) || d == b)
					q.Add(new Tuple<int, int>(c, d));
			}

			// Empty Jug2
			q.Add(new Tuple<int, int>(a, 0));

			// Empty Jug1
			q.Add(new Tuple<int, int>(0, b));
		}


		if (!isSolvable)
			Console.WriteLine("No solution");
	}


	static void Main()
	{
		int Jug1 = 4, Jug2 = 3, target = 2;
		Console.WriteLine("Path from initial state "
						+ "to solution state ::");

		BFS(Jug1, Jug2, target);
	}
}


