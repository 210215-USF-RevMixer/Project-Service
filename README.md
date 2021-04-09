# Project-Service

### Description
Rest API service for adding, updating, and removing projects for RevMixer.  

#### API Controllers
<table>
<tr><th><h3>UserProject</h3></th><th><h3>SavedProject</h3></th><th><h3>Track</h3></th><th><h3>Pattern</h3></th></tr>
<tr>
<th><h4>Endpoints</h4></th>
</tr>
<tr>
<td>

Get | Post | Put | Delete
----|----|----|----
/api/ | /api/ | /api/ | /api/
/api/ | /api/ | /api/ | /api/

</td><td>

Get | Post | Put | Delete
----|----|----|----
/api/ | /api/ | /api/ | /api/
/api/ | /api/ | /api/ | /api/

</td>
<td>

Get | Post | Put | Delete
----|----|----|----
/api/ | /api/ | /api/ | /api/
/api/ | /api/ | /api/ | /api/

</td><td>

Get | Post | Put | Delete
----|----|----|----
/api/ | /api/ | /api/ | /api/
/api/ | /api/ | /api/ | /api/

</td>
</tr> 

<tr>
<th><h4>Model Properties</h4></th>
</tr>

<td>

DataType | Variable
----|----
int|Id
int|userId
int|projectId
bool|owner
SavedProject|savedProject

</td>
<td>

DataType | Variable
----|----
int|Id
string|projectName
int|bPM
ICollection\<UserProject>|userProjects
ICollection\<Track>|tracks

</td>
<td>

DataType | Variable
----|----
int|Id
int|projectId
SavedProject|savedProject
Sample|sample
Pattern|pattern
int|sampleId
int|patternId

</td>
<td>

DataType | Variable
----|----
int|Id
string|patternData
ICollection\<Track>|tracks


</td>
</tr>
</table>
<hr />
<hr />
<table>
<tr><th><h3>Sample</h3></th><th><h3>SamplePlaylist</h3></th><th><h3>SampleSets</h3></th></tr>
<tr>
<th><h4>Endpoints</h4></th>
</tr>
<tr>
<td>

Get | Post | Put | Delete
----|----|----|----
/api/Sample | /api/Sample | /api/Sample/{id} | /api/Sample/{id}
/api/Sample/{id} | | | 
/api/Sample/{userID} | | | 

</td><td>

Get | Post | Put | Delete
----|----|----|----
/api/ | /api/ | /api/ | /api/
/api/ | /api/ | /api/ | /api/

</td>
<td>

Get | Post | Put | Delete
----|----|----|----
/api/ | /api/ | /api/ | /api/
/api/ | /api/ | /api/ | /api/

</td></tr> 

<tr>
<th><h4>Model Properties</h4></th>
</tr>

<td>

DataType | Variable
----|----
int|Id
int|userId
string|sampleName
string|sampleLink
ICollection\<Track>|track
bool|isPrivate
bool|isApproved
bool|isLocked

</td>
<td>

DataType | Variable
----|----
int|Id
int|sampleId
int|sampleSetId

</td>
<td>

DataType | Variable
----|----
int|Id
string|name

</td>
</tr>
</table>

### Requirements

### Setup

### Testing

### Configuration




