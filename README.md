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

Get | Post 
----|----
/api/UserProject | /api/UserProject
/api/UserProject/{userProjectID} |  

</td><td>

Get | Post 
----|----
/api/SavedProject | /api/SavedProject
/api/SavedProject/{savedProjectID} | 

</td>
<td>

Get | Post 
----|----
/api/Track | /api/Track
/api/Track/{trackID} |  

</td><td>

Get | Post 
----|----
/api/Pattern | /api/Pattern
/api/Pattern/{patternID} |  

</td>
</tr>
<tr>
<td>

Put | Delete
----|----
/api/UserProject/{id}  | /api/UserProject/{userProjectID} 

</td><td>

Put | Delete
----|----
/api/SavedProject/{id} | /api/SavedProject/{savedProjectID}

</td>
<td>

Put | Delete
----|----
/api/Track/{id} | /api/Track/{trackID}

</td><td>

Put | Delete
----|----
/api/Pattern/{id} | /api/Pattern/{patternID}

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
<tr><th><h3>Sample</h3></th><th><h3>SamplePlaylist</h3></th><th><h3>SampleSets</h3></th><th><h3>UsersSample</h3></th><th><h3>UsersSampleSets</h3></th></tr>
<tr>
<th><h4>Endpoints</h4></th>
</tr>
<tr>
<td>

Get | Post 
----|----
/api/Sample | /api/Sample 
/api/Sample/{id} | 

</td><td>

Get | Post 
----|----
/api/SamplePlaylist | /api/SamplePlaylist 
/api/SamplePlaylist/{id} |

</td>
<td>

Get | Post 
----|----
/api/SampleSets | /api/SampleSets 
/api/SampleSets/{id} | 

</td><td>

Get | Post 
----|----
/api/UsersSample | /api/UsersSample
/api/UsersSample/{id} | 
/api/UsersSample/User/{userID} |

</td>
<td>

Get | Post 
----|----
/api/UsersSampleSets | /api/UsersSampleSets
/api/UsersSampleSets/{id} | 
/api/UsersSampleSets/User/{userID} |

</td></tr> 
</tr> 
<tr>
<td>

Put | Delete
----|----
/api/Sample/{id} | /api/Sample/{id}

</td><td>

Put | Delete
----|----
/api/SamplePlaylist/{id} | /api/SamplePlaylist/{id}

</td>
<td>

Put | Delete
----|----
/api/SampleSets/{id} | /api/SampleSets/{id}

</td><td>

Put | Delete
----|----
/api/UsersSample/{id} | /api/UsersSample/{id} 

</td>
<td>

Put | Delete
----|----
/api/UsersSampleSets/{id} | /api/UsersSampleSets/{id}

</td></tr> 
</tr> 

<tr>
<th><h4>Model Properties</h4></th>
</tr>

<td>

DataType | Variable
----|----
int|Id
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
<td>

DataType | Variable
----|----
int|Id
int|userId
int|sampleId
bool|isOwner

</td>
<td>

DataType | Variable
----|----
int|Id
int|userId
int|sampleSetsId

</td>
</tr>
</table>
<hr />
<hr />
<table>
<tr><th><h3>SampleBlob</h3></th></tr>
<tr>
<th><h4>Endpoints</h4></th>
</tr>
<tr>
<td>
<table>
<th>Post</th>
<tr><td>/api/SampleBlob</td></tr>
</table>

</td></tr> 
</tr> 
</table>

### Requirements

### Setup

### Testing

### Configuration




