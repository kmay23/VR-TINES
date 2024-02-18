import requests
from os import access
import jwt.utils
import time
import math
import random

developer_id = "169ba5ed-accb-46d3-803e-b6dc771b12ed"
key_id = "95e01146-a74f-4804-91b6-cc480ffca83c"
signing_secret = "2aUz2Ou0Cp14bFShubCFMCTmrlcqMInBXH12In7PAzY"

token = jwt.encode(
    {
        "aud": "doordash",
        "iss": developer_id,
        "kid": key_id,
        "exp": str(math.floor(time.time() + 300)),
        "iat": str(math.floor(time.time())),
    },
    jwt.utils.base64url_decode(signing_secret),
    algorithm="HS256",
    headers={"dd-ver": "DD-JWT-V1"},
)

# print(token)

endpoint = "https://openapi.doordash.com/drive/v2/deliveries/"

headers = {
    "Accept-Encoding": "application/json",
    "Authorization": "Bearer " + token,
    "Content-Type": "application/json",
}

# CREATE A DELIVERY FOR USER A - west coast
random_id = random.randint(100000, 999999)
request_body = {
    "external_delivery_id": f"D-{random_id}",
    "pickup_address": "2675 Middlefield Rd C, Palo Alto, CA 94306",
    "pickup_business_name": "Teaspoon Tea",
    "pickup_phone_number": "+16505555555",
    "pickup_instructions": "Pick up from the front shelf.",
    "dropoff_address": "475 Via Ortega, Stanford, CA 94305",
    "dropoff_business_name": "Stanford dormitories",
    "dropoff_phone_number": "+16505555555",
    "dropoff_instructions": "Enter gate code 1094 on the callbox.",
    "order_value": 1999,
}
create_delivery = requests.post(endpoint, headers=headers, json=request_body)
print(create_delivery.status_code)
print(create_delivery.text)
print(create_delivery.reason)

# CREATE A DELIVERY FOR USER B - east coast
random_id = random.randint(100000, 999999)
request_body = {
    "external_delivery_id": f"D-{random_id}",
    "pickup_address": "27 Witherspoon St, Princeton, NJ 08542",
    "pickup_business_name": "Junbi Tea",
    "pickup_phone_number": "+19038923060",
    "pickup_instructions": "Give name to waiter.",
    "dropoff_address": "Rockefeller College, Princeton, NJ 08540",
    "dropoff_business_name": "Princeton dormitories",
    "dropoff_phone_number": "+19082948204",
    "dropoff_instructions": "Leave outside door.",
    "order_value": 1999,
}
create_delivery = requests.post(endpoint, headers=headers, json=request_body)
print(create_delivery.status_code)
print(create_delivery.text)
print(create_delivery.reason)
