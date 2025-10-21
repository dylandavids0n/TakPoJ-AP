#Enter types here. 

from typing import NamedTuple, Optional
from BaseClasses import ItemClassification

class ItemData(NamedTuple):
    ap_code: Optional[int]
    classification: ItemClassification
    count: Optional[int] = 1