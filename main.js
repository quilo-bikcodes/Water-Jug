
	function BFS(a,b,target)
	{
		let m = new Array(1000);
		for(let i=0;i<1000;i++){
			m[i]=new Array(1000);
			for(let j=0;j<1000;j++)
			{
				m[i][j]=-1;
			}
		}

		let isSolvable = false;
		let path = [];

		let q = []; // queue to maintain states
		q.push([0,0]); // Initialing with initial state

		while (q.length!=0) {

			let u = q[0]; // current state

			q.shift(); // pop off used state

			// doesn't met jug constraints
			if ((u[0] > a || u[1] > b ||
				u[0] < 0 || u[1] < 0))
				continue;

			// if this state is already visited
			if (m[u[0]][u[1]] > -1)
				continue;

			// filling the vector for constructing
			// the solution path
			path.push([u[0],u[1]]);

			// marking current state as visited
			
			m[u[0]][u[1]] = 1;
			

			if (u[0] == target || u[1] == target) {
				isSolvable = true;
				if (u[0] == target) {
					if (u[1] != 0)

						// fill final state
						path.push([u[0],0]);
				}
				else {
					if (u[0] != 0)

						// fill final state
						path.push([0,u[1]]);
				}

				// print the solution path
				let sz = path.length;
				for (let i = 0; i < sz; i++)
					document.write("(" + path[i][0]
						+ ", " + path[i][1] + ")<br>");
				break;
			}

			q.push([u[0],b]); // fill Jug2
			q.push([a,u[1]]); // fill Jug1

			for (let ap = 0; ap <= Math.max(a, b); ap++) {

				// pour amount ap from Jug2 to Jug1
				let c = u[0] + ap;
				let d = u[1] - ap;

				// check if this state is possible or not
				if (c == a || (d == 0 && d >= 0))
					q.push([c,d]);

				// Pour amount ap from Jug 1 to Jug2
				c = u[0] - ap;
				d = u[1] + ap;

				// check if this state is possible or not
				if ((c == 0 && c >= 0) || d == b)
					q.push([c,d]);
			}

			q.push([a,0]); // Empty Jug2
			q.push([0,b]); // Empty Jug1
		}


		if (!isSolvable)
			document.write("No solution");
	}
	
	let Jug1 = 4, Jug2 = 3, target = 2;
	document.write("Path from initial state " +
				"to solution state ::<br>");
	BFS(Jug1, Jug2, target);
	
	

