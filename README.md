# Recognet

Simple .NET library for pose and gesture recognition. 
The implementation targets Kinect, but the underlying ideas can be reused in other scenarios.
The library attempts to provide some descriptive mechanisms to express human poses and gestures.

For example:

``` csharp
    Pose surrender = Body.BothHands.Above(JointType.Head);
```

Pose definitions are intended to remain close to a human-readable description.

## Pose description and recognition

A pose is represented by an instance of a class derived from `Pose`.
The pose recognition is done following a Fuzzy Logic approach with the implementation of the `Matches` method declared in the `Pose` class.
This method takes an instance of  `Skeleton`, as provided by Kinect, and returns a real value between 0 and 1 indicating how close the detected body is to the pose.
Teh library provides conversions between `Pose` and `Func<Skeleton, double>` so any method with a matching signature can be used as a pose and vice versa.
Pose instances can be combined using `&` and `|` operators.
For example:

``` csharp
    Pose one = Body.RightHand.Above(JointType.Head);
    Pose two = Body.LeftHand.Below(JointType.Head);

    Pose combined = one & two;
```

The `Body` class includes a set of shortcuts to ease pose definitions. These shortcuts are instances of classes that select joints, segments or limbs from a skeleton. Some relations between skeleton parts can be expressed using the provided shortcuts as in the following example:

``` csharp
    Pose pointing = Body.LeftArm.PointingForward() & Body.LeftArm.IsStraight();
```  
Skeletons can be matched to a defined pose using the `Holds` method of one of the `Skeleton` class extensions:

``` csharp
    Skeleton sk = ...;
    Pose pose = ...;
    double tolerance = ...;

    if(pose.Matches(skeleton) > tolerance) {
        Console.WriteLine("The skeleton holds the pose");
    }

    if(sk.Holds(pose) > tolerance) {
        Console.WriteLine("The skeleton holds the pose");
    }

    if(sk.Holds(pose, tolerance)) {
        Console.WriteLine("The skeleton holds the pose");
    }
```

## Development

This library is currently under development. It hasn't been properly tested and lots of changes are expected.





