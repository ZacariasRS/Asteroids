The adjustment of the game constants are done via ScriptableObjects that hold the configuration of each system.

They are easily obtained if you put the line "configuration t:ScriptableObject" on the project search bar.

At the moment, we have 4 types of configuration:

"<Type>AsteroidConfiguration", where <Type> is the type of asteroid being configured. It only shows the variables that concern that type of asteroid. All the possible variables that can be found are:
- Speed
Asteroid speed going forward
- Points
Points that get added for destroying this kind of asteroid
- Asteroids To Spawn
Number of Asteroids to spawn at the time of destroying this asteroid. (If in a future an asteroid could spawn several types of asteroid, we could change this to a list of asteroids, but there is no need at the moment).

"BulletConfiguration", with the variables:
- Speed
Bullet speed going forward
- Time to live
Time that the bullet keeps going before deactivating itself

"Ship Configuration", with the variables:
- Max speed
Maximum speed that the ship can achieve
- Speed
Speed added to the ship when the player goes forward or backward
- Rotation speed
Speed at which the ship rotates when the player goes left or right
- Linear drag
Inertia of the ship when the player stop issuing movement
- Fire cooldown
How much time the ship has to wait in order to fire again
