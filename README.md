# Recognet

Simple .NET library for pose and gesture recognition. 
The implementation targets Kinect, but the underlying ideas can be reused.
The library provides descriptive mechanisms to express poses and gestures.

For example:

``` csharp
    Pose surrender = Body.BothHands.Above(JointType.Head);
```

In this way, a pose definition remains near to a human-readable description.

##Pose description and recognition

A pose is represented by an instance of a class derived from `Pose`.
Pose recognition is done following a Fuzzy Logic approach with the implementation of the `Matches` method.
This method takes an instance of  `Skeleton` and returns a real value between 0 and 1 indicating how close the detected body is to the pose.
There are conversions between `Pose` and `Func<Skeleton, double>` so any method with a matching siganture can be used as a pose and vice versa.
Poses can be combined using `&` and `|` operators.
For example:

``` csharp
    Pose one = Body.RightHand.Above(JointType.Head);
    Pose two = Body.LeftHand.Below(JointType.Head);

    Pose combined = one & two;
```

The `Body` class includes a set of shortcuts to ease the definition of a pose. Those shortcuts are instances of classes that perform selections of joints, segments or limbs from a skeleton. They construct poses characterizing relations between skeleton parts. For example if one joint is below or to the left of another, of if a limb is straight.

``` csharp
    Pose pointing = Body.LeftArm.PointingForward() & Body.LeftArm.IsStraight();
```  
Skeletons can be matched to a defined pose using the `Matches` method of one of the `Skeleton` class extensions:

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

##Development

This library is currently on development. It hasn't been properly tested and lots of changes are expected.





