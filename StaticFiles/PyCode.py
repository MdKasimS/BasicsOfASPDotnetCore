class CustomError(Exception):
    pass

def divide (num1, num2):
    
    if(num2==0):
        raise CustomError("This is error")
    
    return num1/num2



try: 
    for i in range(1,101):
       print(f'for i = {i} => {divide(i*5, i-11)}')
except CustomError as e:
    print(f'{i} gave error {e.with_traceback}')
finally:
    print("Woking like JS now")

