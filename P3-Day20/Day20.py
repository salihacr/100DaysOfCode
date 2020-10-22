"""
    This function controls whether a triangle can be drawn from the given edges.
"""
def isTriangle(a, b, c):
    if ((a < b + c) and (b < a + c) and (c < a + b)):
        if ((a > abs(b - c)) and (b > abs(a - c)) and (c > abs(a - b))):
            print("The triangle can drawn with {0}, {1} and {2} edges.".format(a,b,c))
    else:
        print("The triangle can not drawn with {0}, {1} and {2} edges.".format(a,b,c))

isTriangle(3,4,7)
isTriangle(3.1,4,7)


"""
    Constructor Example
"""
class Date :
    day = 0
    month = 0
    year = 0
    def __init__(self, day, month, year):
        self.day = day
        self.month = month
        self.year = year
    
class Person :
    firstName = 0
    lastName = 0
    birthDate = Date(0,0,0)

    def __init__(self, firstName, lastName, birthDate):
        self.firstName = firstName
        self.lastName = lastName
        self.birthDate = birthDate

personList = []
    
def setInfo(person):
    personList.append(person)
    return personList
    
def returnList():
    return personList

def sortInfo(pList):
    for i in range(len(pList)):
        print("{0} {1} {2} ".format(pList[i].firstName, pList[i].lastName, pList[i].birthDate))
    
def displayInfo(person):
    print("{0} {1} {2} ".format(person.firstName, person.lastName, person.birthDate))

    
p1 = Person("John","Doe", (25,11,1989))
p2 = Person("Make","Doe", (25,12,1979))
p3 = Person("Jim","Doe", (25,12,1959))
p4 = Person("Won","Doe", (25,12,1969))

setInfo(p1)
setInfo(p2)
setInfo(p3)
setInfo(p4)

sortInfo(personList)