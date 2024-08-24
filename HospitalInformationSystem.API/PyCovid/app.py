import torch.nn as nn
import torch

class YourModel(nn.Module):
    def __init__(self):
        super(YourModel, self).__init__()
        # Define your model layers here
    
    def forward(self, x):
        # Define forward pass
        return x

model = YourModel()
model.load_state_dict(torch.load('C:\Users\c.delivery for lap\source\repos\HospitalInformationSystem\HospitalInformationSystem.API\PyCovid\model2.pth'))
model.eval()


